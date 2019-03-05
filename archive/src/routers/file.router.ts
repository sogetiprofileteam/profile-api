import { Router } from 'express';
import { Request, Response, Application } from 'express';
import { Db, Collection, ObjectId, GridFSBucket } from 'mongodb';

export class FileRouter {
  
  private filesUrl: string;
  private readonly collection: Collection<any>;
  public router: Router;
  public readonly resourceName = 'file';

  constructor(private db: Db, private apiHost: string) {
    if (!db) { throw 'db is null or undefined.'; }
    this.router = Router();
    this.mountRoutes(this.router);
    this.filesUrl = this.apiHost + '/file';
    this.collection = db.collection('fs.files');
  }

  private mountRoutes(router: Router): void {
    
    router.post('/', (req: Request, res: Response) => {
      const bucket = new GridFSBucket(this.db);
      req
        .pipe(bucket.openUploadStream('file', { contentType: req.headers["content-type"]}))
        .on('finish', (object: any) => {
          const location = `${this.filesUrl}/${object._id}`;
          res.setHeader('Location', location);
          res.status(201);
          res.send(location);
        })
        .on('error', (error: Error) => {
          console.log(error);
          res.sendStatus(500);
        });
    });

    router.get('/:id', async (req: Request, res: Response) => {
      const fileId = req.params.id;
      if (!fileId) {
        res.status(400);
        res.send('id parameter is required.');
        return;
      }
      const bucket = new GridFSBucket(this.db);
      const file = await bucket.find({ "_id": new ObjectId(fileId)}).next();
      if (!file) {
        res.sendStatus(404);
        return;
      }

      res.setHeader('Content-Type', file.contentType);
      bucket.openDownloadStream(new ObjectId(fileId))
        .pipe(res)
        .on('finish', () => res.sendStatus(200))
        .on('error', () => res.sendStatus(500));
    });
  }
}
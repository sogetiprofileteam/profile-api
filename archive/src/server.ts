import * as express from 'express';
import { Request, Response, Application, NextFunction } from 'express';
import { MongoClient, Db, MongoError } from 'mongodb';
import { corsMiddleware } from './utils';
import { ProfileRouter } from './routers/profile.router';
import { SearchRouter } from './routers/search.router';
import { FileRouter } from './routers/file.router';

const dbUri = process.env.DB_CONN;
if (!dbUri) {
  throw 'Missing env var DB_CONN.'
}
let db: Db;

process.on('uncaughtException', (err: Error) => {

});

const app: Application = express();
app.use(corsMiddleware);
app.use(express.json());
app.use(function (err: any, req: Request, res: Response, next: NextFunction) {
  res.sendStatus(500);
});

// Initialize connection once
(async () => { 
  try {
    const client = await MongoClient.connect(dbUri);
    db = client.db();
  } catch (error) {
    console.log(error);
  }

  const profileRouter = new ProfileRouter(db);
  app.use('/profile', profileRouter.router);
  const searchRouter = new SearchRouter(db);
  app.use('/search', searchRouter.router);
  const fileRouter = new FileRouter(db, process.env.API_HOST);
  app.use('/file', fileRouter.router);

  // Start the application after the database connection is ready
  app.listen(process.env.PORT || 3000);
  console.log("Listening on port 3000");
})();
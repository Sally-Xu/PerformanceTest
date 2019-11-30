const MongoClient = require('mongodb').MongoClient;

var express = require('express');

const app = express(),
  port = process.env.PORT || 5006;
  bodyParser = require('body-parser');
  app.use(bodyParser.urlencoded({ extended: true }));
  app.use(bodyParser.json());
  
  var routes = require('./api/routes/nodeRoutes'); //importing route
  routes(app); //register the route

  const url = "mongodb://root:example@localhost:27017";
  MongoClient.connect(url, { useUnifiedTopology: true }, (err,  client) => {
    const db = client.db("AppDb");
    app.locals.db = db;
    app.listen(port);
    console.log('test RESTful API server started on: ' + port);
  });
  
  
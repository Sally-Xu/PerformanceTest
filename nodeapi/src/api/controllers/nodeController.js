'use strict';

exports.node = function(req, res) {
  let list = [];
  const n = req.params["n"];
  for(var i = 0; i < n; i++)
  {
    list.push("test" + i);
  }
  res.send(list);
};

exports.data = function(req, res) {
  const db = req.app.locals.db;
  db.collection('author').find({}).toArray((err, items)=> {
    res.send(items);
  });
}

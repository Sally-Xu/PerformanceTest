'use strict';

exports.note = function(req, res) {
  let list = [];
  const n = req.params["n"];
  for(var i = 0; i < n; i++)
  {
    list.push("test" + i);
  }
  res.json(list);
};

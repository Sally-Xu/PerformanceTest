'use strict';
module.exports = function(app) {
  var node = require('../controllers/nodeController');
  // Routes
  app.route('/node/data')
    .get(node.data);
  app.route('/node/:n')
    .get(node.node);
};
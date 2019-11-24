'use strict';
module.exports = function(app) {
  var note = require('../controllers/noteController');

  // Routes
  app.route('/note/:n')
    .get(note.note);
};
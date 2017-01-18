
var gulp = require("gulp");
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var foreach = require("gulp-foreach");
var gulpConfig = require("./gulp-config.js")();
var deleteFiles = require("del");
var runSequence = require("run-sequence");
var newer = require("gulp-newer");
var csso = require('gulp-csso');
var gulpFilter = require('gulp-filter');
var flatten = require('gulp-flatten');
var extender = require('gulp-html-extend');
var htmltidy = require('gulp-htmltidy');
var jshint = require('gulp-jshint');
var jshintStylish = require('jshint-stylish');
var rm = require('gulp-rimraf');
var sass = require('gulp-sass');
var browserSync = require('browser-sync').create();
var reload = browserSync.reload;
var useref = require('gulp-useref');
var gutil = require('gulp-util');
var opn = require('opn');
var streamqueue = require('streamqueue');
var fileinclude = require('gulp-file-include');
var uglify = require('gulp-uglify');
var size = require('gulp-size');

module.exports.config = gulpConfig;

//***************************************************************************************
// Single-run tasks
//***************************************************************************************

gulp.task("publish-configs", function () {
  var root = "./{Project,Feature,Foundation}/";
   var roots = [root + "**/**/App_Config", "!" + root + "**/**/obj/**/App_Config"];
   var files = "/**/*.config";
   var destination = gulpConfig.webRoot + "\\App_Config";
   return gulp.src(roots, { base: root }).pipe(
     foreach(function (stream, file) {
        console.log("Publishing from " + file.path);
        gulp.src(file.path + files, { base: file.path })
          .pipe(newer(destination))
          .pipe(debug({ title: "Copying " }))
          .pipe(gulp.dest(destination));
        return stream;
     })
   );
});

gulp.task("publish-views", function () {
  var root = "./{Project,Feature,Foundation}/";
  var roots = [root + "**/**/Views", "!" + root + "**/**/obj/**/Views", "!" + root + "**/**/bin/**"];
   var files = "/**/*.cshtml";
   var destination = gulpConfig.webRoot + "\\Views";
   return gulp.src(roots, { base: root }).pipe(
     foreach(function (stream, file) {
        console.log("Publishing from " + file.path);
        gulp.src(file.path + files, { base: file.path })
          .pipe(newer(destination))
          .pipe(debug({ title: "Copying " }))
          .pipe(gulp.dest(destination));
        return stream;
     })
   );
});

gulp.task("publish-feature-scripts", function () {
   var root = "./";
   var roots = [root + "Feature/**/**/Scripts", "!" + root + "/**/node_modules/**"];
   var files = "/**/*.js";
   var destination = gulpConfig.webRoot + "\\Scripts";
   return gulp.src(roots, { base: root }).pipe(
     foreach(function (stream, file) {
        console.log("Publishing from " + file.path);
        gulp.src(file.path + files, { base: file.path })
          .pipe(newer(destination))
          .pipe(debug({ title: "Copying " }))
          .pipe(gulp.dest(destination));
        return stream;
     })
   );
});

gulp.task("publish-scripts", function () {
  var root = "./";
  var roots = [root + "/{Project,Foundation}/**/**/scripts"];
  var files = "/*.js";
  var destination = gulpConfig.webRoot + "/Scripts";
  return gulp.src(roots, { base: root }).pipe(
    foreach(function (stream, file) {
      console.log("Publishing from " + file.path);
      gulp.src(file.path + files, { base: file.path })
        .pipe(newer(destination))
        .pipe(debug({ title: "Copying " }))
        .pipe(gulp.dest(destination));
      return stream;
    })
  );
});

gulp.task("publish-css", function () {
  var root = "./";
  var roots = [root + "/{Project,Foundation}/**/**/Content"];
  var files = "/*.css";
  var destination = gulpConfig.webRoot + "/Content";
  return gulp.src(roots, { base: root }).pipe(
    foreach(function (stream, file) {
      console.log("Publishing from " + file.path);
      gulp.src(file.path + files, { base: file.path })
        .pipe(newer(destination))
        .pipe(debug({ title: "Copying " }))
        .pipe(gulp.dest(destination));
      return stream;
    })
  );
});

//***************************************************************************************
// MSBuild tasks
//***************************************************************************************

gulp.task("Publish-Site", ['Build-Foundation-Projects', 'Build-Feature-Projects', 'Build-Project-Projects']);

gulp.task("Build-Foundation-Projects", function () {
  return publishProjects("./Foundation/**/**");
});

gulp.task("Build-Feature-Projects", function () {
  return publishProjects("./Feature/**/**");
});

gulp.task("Build-Project-Projects", function () {
  return publishProjects("./Project/**/**");
});

var publishProjects = function (location, dest) {
  dest = dest || gulpConfig.webRoot;
  console.log("publish to " + dest + " folder");
  return gulp.src([location + "/*.csproj"])
    .pipe(foreach(function (stream, file) {
      return stream
        .pipe(debug({ title: "Building project:" }))
        .pipe(msbuild({
          targets: ["Build"],
          configuration: gulpConfig.buildConfiguration,
          logCommand: false,
          verbosity: "minimal",
          maxcpucount: 0,
          toolsVersion: 14.0,
          properties: {
            DeployOnBuild: "true",
            DeployDefaultTarget: "WebPublish",
            WebPublishMethod: "FileSystem",
            DeleteExistingFiles: "false",
            publishUrl: dest,
            _FindDependencies: "false"
          }
        }));
    }));
};
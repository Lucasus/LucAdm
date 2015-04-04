/// <vs />
// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var inject = require('gulp-inject');
var series = require('stream-series')
var debug = require('gulp-debug');
var less = require('gulp-less');
var path = require('path');
var newer = require('gulp-newer');

var config = {
    lib: [
        'bower_components/angular/angular.js',
        'bower_components/angular-bootstrap/ui-bootstrap-tpls.js'],
    src: ['app/app.js',
        'app/**/*.js',
        '!app/all.js'],
    css: ['bower_components/bootstrap/dist/css/bootstrap.css',
          'bower_components/bootstrap/dist/css/bootstrap.css.map',
        '!css/all.css'],
    fonts: ['bower_components/bootstrap/dist/fonts/*.*'],
    less: ['bower_components/bootstrap/less/bootstrap.less']
}
 
// Common tasks:
gulp.task('clean', function(){
  del.sync(['app/all.js'])
//  del.sync(['lib/*.*'])
});
 
gulp.task('fonts', function () {
    return gulp.src(config.fonts)
    .pipe(newer('./fonts'))
    .pipe(gulp.dest('./fonts'));
});

gulp.task('less-debug', function () {
    return gulp.src(config.less)
      .pipe(newer('./css'))
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
      }))
      .pipe(gulp.dest('./css'));
});
// Debug tasks:
gulp.task('scripts-debug', ['clean'], function () {
    return gulp.src(config.lib)
      .pipe(newer('./lib'))
      .pipe(gulp.dest('./lib'));
});

gulp.task('index-debug', ['less-debug', 'scripts-debug'], function () {
    return gulp.src('index.html')
        .pipe(inject(series(gulp.src(['css/*.css', '!css/all.css']), gulp.src('lib/*.js'), gulp.src(config.src)).pipe(debug())))
        .pipe(gulp.dest('.'));
});

// Release tasks
gulp.task('scripts-release', ['clean'], function () {
    return gulp.src(config.lib.concat(config.src))
      .pipe(debug())
      .pipe(concat('all.js'))
      .pipe(gulp.dest('./app'));
});


gulp.task('css-release', function () {
    return gulp.src(config.css)
    .pipe(debug({title: 'css-release'}))
    .pipe(concat('all.css'))
    .pipe(gulp.dest('./css'));
});


gulp.task('index-release', ['css-release', 'scripts-release'], function () {
    return gulp.src('index.html')
        .pipe(inject(gulp.src(['css/all.css', 'app/all.js'])))
        .pipe(gulp.dest('.'));
});

//Set a default tasks
gulp.task('debug', ['fonts', 'scripts-debug', 'less-debug', 'index-debug'], function () { });
gulp.task('release', ['fonts', 'scripts-release', 'css-release', 'index-release'], function () { });


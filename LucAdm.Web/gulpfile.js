/// <vs AfterBuild='scripts' />

// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var inject = require('gulp-inject');
var series = require('stream-series')
var debug = require('gulp-debug');

var config = {
    lib: [
        'bower_components/angular/angular.js',
        'bower_components/angular-bootstrap/ui-bootstrap.js'],
    src: ['app/**/*.js',
        '!app/**/*.min.js',
        '!app/all.js'],
    css: ['bower_components/bootstrap/dist/css/bootstrap.css',
        '!css/all.css'],
}
 
gulp.task('clean', function(){
  del.sync(['app/all.js'])
});
 

// Debug tasks:
gulp.task('scripts-debug', ['clean'], function () {
    return gulp.src(config.lib)
      .pipe(gulp.dest('./lib'));
});

gulp.task('css-debug', function () {
    return gulp.src(config.css)
    .pipe(gulp.dest('./css'));
});

gulp.task('index-debug', ['css-debug', 'scripts-debug'], function () {
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
gulp.task('debug', ['scripts-debug', 'css-debug', 'index-debug'], function () { });
gulp.task('release', ['scripts-release', 'css-release', 'index-release'], function () { });


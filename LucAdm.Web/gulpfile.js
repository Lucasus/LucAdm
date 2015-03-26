/// <vs AfterBuild='scripts' />

// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');

var config = {
   //Include all js files but exclude any min.js files
    lib: [
        'bower_components/angular/angular.js',
        'bower_components/angular-bootstrap/ui-bootstrap.js'],
        //'app/**/*.js',
        //'!app/**/*.min.js'],
    css: ['bower_components/bootstrap/dist/css/bootstrap.css']
 }
 
// Synchronously delete the output file(s)
gulp.task('clean', function(){
  del.sync(['app/all.min.js'])
});
 
// Combine and minify all files from the app folder
gulp.task('scripts', ['clean'], function() {
 
  return gulp.src(config.src)
//    .pipe(uglify())
//    .pipe(concat('all.min.js'))
    .pipe(gulp.dest('app/lib'));
});

gulp.task('css', function () {
    return gulp.src(config.css)
    .pipe(gulp.dest('app/css'));
});
 
//Set a default tasks
gulp.task('default', ['scripts', 'css'], function(){});
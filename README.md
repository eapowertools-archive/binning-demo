# Status
[![Project Status: Unsupported – The project has reached a stable, usable state but the author(s) have ceased all work on it. A new maintainer may be desired.](https://www.repostatus.org/badges/latest/unsupported.svg)](https://www.repostatus.org/#unsupported)

# binning-demo
A simple implementation of a NP-Hard problem.

A few notes:
This is built in .net core. It'll run on any platform, the exe package in the release is fully self contained and should run on any windows environment.


How to use it.

1) You need an 'input.txt' file beside the executable. You can run the exe from the command prompt.

The input.txt file should have two lines, the first line is the threshold for a bucket, the 2nd line is a list of numbers.

Example:

```
120
82.3, 69.1, 67.4, 64.9, 63.0, 56.6, 53.1, 48.4, 47.4, 46.4, 41.0, 39.7, 39.6, 38.3, 34.5, 33.5, 30.1, 29.7, 29.5, 26.8, 26.7, 26.3, 24.4, 24.4, 24.4, 24.4, 24.4, 23.5, 23.4, 23.4, 20.9, 19.6, 19.3, 18.8, 18.7, 18.4, 18.2, 18.0, 17.9, 17.9, 17.2, 16.9, 16.7, 16.4, 16.4, 82.3
```

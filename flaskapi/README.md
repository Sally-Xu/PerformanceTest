
## Description

Python Flask framework Web Api for Performance Testing.

## Installation

```bash
$ python3 app
```

## Running the app

```bash
$ python3 app
```

# Performance Bechmark testing
```bash
  # running 10 threads 200 connections for 30 sec, get a simple 1000 items list
  wrk -t10 -c200 -d30s http://localhost:5008/flask/1000
  # you can change that 1000 to any number to simulate the length of the tasks running on the server to see how it affect the load performance 
```



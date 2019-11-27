# Performance Benchmarks on NodeJs, NestJs and DotNet Core
3 simple Web Api Projects: nodeapi, nestapi and dotnetapi.
The Api endpoint builds a n number items list and returns the list

The Api End Points are: 
http://localhost:5005/dotnet/:n
http://localhost:5006/node/:n
http://localhost:5007/nest/:n

where n can be any number.

# Performance Bechmark testing
```bash
  # running 10 threads 200 connections for 30 sec, get a simple 1000 items list
  wrk -t10 -c200 -d30s http://localhost:5005/dotnet/1000
  wrk -t10 -c200 -d30s http://localhost:5006/node/1000
  wrk -t10 -c200 -d30s http://localhost:5007/nest/1000
  # you can change the n to any number to simulate the length of the tasks running on the server to see how it affect the load performance 
```

# Result




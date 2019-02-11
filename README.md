# Hush
Dynamic managed assembly (IL) fetch &amp; in-memory execute PoC

Run HushServer on host, like this:
```
  python HushServer.py
```

Remember that when running HushServer, any modules must be present in the working directory for them to be served.

Run Hush on target, currently which payload is fetched, as well as where the manager lies is hardcoded. To be fixed.

It looks like this:

### Server

![Server](https://github.com/naliferopoulos/Hush/blob/master/Screenshots/Hush-Server.png)

### Agent 

![Agent](https://github.com/naliferopoulos/Hush/blob/master/Screenshots/Hush-Agent.png)

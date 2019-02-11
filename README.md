# Hush
Dynamic managed assembly (IL) fetch &amp; in-memory execute Command &amp; Control Framework

### How does this work?

Hush is run on the victim, and connects back to the HushServer, which is run on the attacker. It then proceeds to request a command from the attacker. Once the command is received, Hush requests a managed .NET assembly from the HushServer, which implements the requested command, fetches it in-memory and then proceeds to execute it, sending back the results.

I made a diagram, but it sucks...

![Diagram](https://github.com/naliferopoulos/Hush/blob/master/Screenshots/Hush-Framework.png)

### Great, how do I run it?

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


### So what modules are available?

- FetchCurrentUser --> Fetches the current system user.
- ExamplePayload --> Does nothing. Serves as a starting point for implementing modules.

### Is a C# REPL possible?

A C# REPL is definitely possible given the current implementation of the framework, but has not yet been implemented.

### Can it Mimikatz, Kerberoast, or do anything useful at all?

Not yet friend, not yet. Check back in X days/weeks/years.

### Looks good (does it really?!), but why?

I am sure there are better/more useful C# C2s out there, but I wanted to see what it takes to make one. It is a learning tool as it is. If in any case it proves useful, I'd like to hear about it.


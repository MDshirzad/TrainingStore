 
import pika
class MQhandler:
    def __init__(self,ip,port,username,password):
        self.ip=ip
        self.port = port
        self.username=username
        self.password = password
        self.connectToMq()

    def  connectToMq(self):
       credentials = pika.PlainCredentials(self.username, self.password)
       connection_params = pika.ConnectionParameters(self.ip,self.port,credentials=credentials)
       self.connection=pika.BlockingConnection(connection_params)
    def channelMq(self):
        return self.connection.channel()

 
from RabbitHandler import MQhandler
from Configs.Credentials import *

def callback(ch, method, properties, body):
    
    ch.basic_ack(delivery_tag=method.delivery_tag)
mq = MQhandler(ip= Rabbit_ip,port=Rabbit_port,username=Rabbit_username,password=Rabbit_password)
channel = mq.channelMq()
channel.exchange_declare("Stock_Exchange",  exchange_type='direct')
channel.queue_declare("Stock_Queue")
channel.queue_bind("Stock_Queue","Stock_Exchange","Transferer")
channel.basic_consume(queue='Stock_Queue' , on_message_callback=callback)
 
channel.start_consuming()
 
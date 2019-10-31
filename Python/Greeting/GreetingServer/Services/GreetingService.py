import greeting_pb2
import greeting_pb2_grpc

class GreetingService(greeting_pb2_grpc.GreetingServiceServicer):

    def Greet(self, request, context):
        return greeting_pb2.GreetingResponse(message = f'Hello, {request.sender_name}.')
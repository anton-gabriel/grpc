import calculator_pb2
import calculator_pb2_grpc
from Utils.Calculator import Calculator

class CalculatorService(calculator_pb2_grpc.CalculatorServiceServicer):
    
    def Calculate(self, request_iterator, context):
        calculator = Calculator()
        for request in request_iterator:
            if request.operand is not None:
                calculator.add_operand(request.operand.value)
            if calculator.can_calculate():
                if request.operation != calculator_pb2.InvalidOperation:
                    print(f'The following operation will be calculated: {request.operation}')
                    yield calculator_pb2.OperationResponse(result = calculator.calculate(request.operation), message = f'Calculated operation: {request.operation}.')
                else:
                    yield calculator_pb2.OperationResponse(result = float(), message = 'Please enter an operation type.')
            else:
                yield calculator_pb2.OperationResponse(result = float(), message = 'Please enter one more operand.')

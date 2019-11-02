import calculator_pb2
import calculator_pb2_grpc

class Calculator(object):

    MINIMUM_OPERANDS = 2

    class Operations(object):
        @staticmethod
        def add(first: float, second: float) -> float:
            return first + second;

        @staticmethod
        def substract(first: float, second: float) -> float:
            return first - second;

        @staticmethod
        def multiply(first: float, second: float) -> float:
            return first * second;

        @staticmethod
        def divide(first: float, second: float) -> float:
            return first / second;

    def __init__(self, *args, **kwargs):
        self.__numbers = []

    def add_operand(self, operand: float):
        self.__numbers.append(operand)

    def can_calculate(self):
        return len(self.__numbers) >= self.MINIMUM_OPERANDS

    def calculate(self, operation: calculator_pb2.OperationType):
        return self.__compute(operation)(self.__get_operand(), self.__get_operand()) if self.can_calculate() else float()

    def __compute(self, operation: calculator_pb2.OperationType):
        if operation == calculator_pb2.Addition:
            return self.Operations.add
        if operation == calculator_pb2.Subtraction:
            return self.Operations.substract
        if operation == calculator_pb2.Multiplication:
            return self.Operations.multiply
        if operation == calculator_pb2.Division:
            return self.Operations.divide
        return self.Operations.add

    def __get_operand(self):
        if self.__numbers:
            return self.__numbers.pop()

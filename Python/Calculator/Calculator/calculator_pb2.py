# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: calculator.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf.internal import enum_type_wrapper
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='calculator.proto',
  package='',
  syntax='proto3',
  serialized_options=_b('\252\002\tGenerated'),
  serialized_pb=_b('\n\x10\x63\x61lculator.proto\"\x18\n\x07Operand\x12\r\n\x05value\x18\x01 \x01(\x01\"P\n\x10OperationRequest\x12\x19\n\x07operand\x18\x01 \x01(\x0b\x32\x08.Operand\x12!\n\toperation\x18\x02 \x01(\x0e\x32\x0e.OperationType\"4\n\x11OperationResponse\x12\x0e\n\x06result\x18\x01 \x01(\x01\x12\x0f\n\x07message\x18\x02 \x01(\t*f\n\rOperationType\x12\x14\n\x10InvalidOperation\x10\x00\x12\x0c\n\x08\x41\x64\x64ition\x10\x01\x12\x0f\n\x0bSubtraction\x10\x02\x12\x12\n\x0eMultiplication\x10\x03\x12\x0c\n\x08\x44ivision\x10\x04\x32K\n\x11\x43\x61lculatorService\x12\x36\n\tCalculate\x12\x11.OperationRequest\x1a\x12.OperationResponse(\x01\x30\x01\x42\x0c\xaa\x02\tGeneratedb\x06proto3')
)

_OPERATIONTYPE = _descriptor.EnumDescriptor(
  name='OperationType',
  full_name='OperationType',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='InvalidOperation', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Addition', index=1, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Subtraction', index=2, number=2,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Multiplication', index=3, number=3,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Division', index=4, number=4,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=182,
  serialized_end=284,
)
_sym_db.RegisterEnumDescriptor(_OPERATIONTYPE)

OperationType = enum_type_wrapper.EnumTypeWrapper(_OPERATIONTYPE)
InvalidOperation = 0
Addition = 1
Subtraction = 2
Multiplication = 3
Division = 4



_OPERAND = _descriptor.Descriptor(
  name='Operand',
  full_name='Operand',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='value', full_name='Operand.value', index=0,
      number=1, type=1, cpp_type=5, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=20,
  serialized_end=44,
)


_OPERATIONREQUEST = _descriptor.Descriptor(
  name='OperationRequest',
  full_name='OperationRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='operand', full_name='OperationRequest.operand', index=0,
      number=1, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='operation', full_name='OperationRequest.operation', index=1,
      number=2, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=46,
  serialized_end=126,
)


_OPERATIONRESPONSE = _descriptor.Descriptor(
  name='OperationResponse',
  full_name='OperationResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='OperationResponse.result', index=0,
      number=1, type=1, cpp_type=5, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='message', full_name='OperationResponse.message', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=128,
  serialized_end=180,
)

_OPERATIONREQUEST.fields_by_name['operand'].message_type = _OPERAND
_OPERATIONREQUEST.fields_by_name['operation'].enum_type = _OPERATIONTYPE
DESCRIPTOR.message_types_by_name['Operand'] = _OPERAND
DESCRIPTOR.message_types_by_name['OperationRequest'] = _OPERATIONREQUEST
DESCRIPTOR.message_types_by_name['OperationResponse'] = _OPERATIONRESPONSE
DESCRIPTOR.enum_types_by_name['OperationType'] = _OPERATIONTYPE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

Operand = _reflection.GeneratedProtocolMessageType('Operand', (_message.Message,), dict(
  DESCRIPTOR = _OPERAND,
  __module__ = 'calculator_pb2'
  # @@protoc_insertion_point(class_scope:Operand)
  ))
_sym_db.RegisterMessage(Operand)

OperationRequest = _reflection.GeneratedProtocolMessageType('OperationRequest', (_message.Message,), dict(
  DESCRIPTOR = _OPERATIONREQUEST,
  __module__ = 'calculator_pb2'
  # @@protoc_insertion_point(class_scope:OperationRequest)
  ))
_sym_db.RegisterMessage(OperationRequest)

OperationResponse = _reflection.GeneratedProtocolMessageType('OperationResponse', (_message.Message,), dict(
  DESCRIPTOR = _OPERATIONRESPONSE,
  __module__ = 'calculator_pb2'
  # @@protoc_insertion_point(class_scope:OperationResponse)
  ))
_sym_db.RegisterMessage(OperationResponse)


DESCRIPTOR._options = None

_CALCULATORSERVICE = _descriptor.ServiceDescriptor(
  name='CalculatorService',
  full_name='CalculatorService',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  serialized_start=286,
  serialized_end=361,
  methods=[
  _descriptor.MethodDescriptor(
    name='Calculate',
    full_name='CalculatorService.Calculate',
    index=0,
    containing_service=None,
    input_type=_OPERATIONREQUEST,
    output_type=_OPERATIONRESPONSE,
    serialized_options=None,
  ),
])
_sym_db.RegisterServiceDescriptor(_CALCULATORSERVICE)

DESCRIPTOR.services_by_name['CalculatorService'] = _CALCULATORSERVICE

# @@protoc_insertion_point(module_scope)

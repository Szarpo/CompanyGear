using System.Text.Json.Serialization;
using CompanyGear.Core.Enums;
using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record CreateGearCommand(TypeOfGearEnum TypeOfDevice, string Model, string SerialNumber, string UteNumber) : IRequest;
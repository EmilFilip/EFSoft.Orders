global using System.Diagnostics.CodeAnalysis;

global using EFSoft.Orders.Api.Configuration;
global using EFSoft.Orders.Api.Endpoints;
global using EFSoft.Orders.Application.Commands.CreateOrder;
global using EFSoft.Orders.Application.Commands.UpdateOrder;
global using EFSoft.Orders.Application.Queries.GetCustomerOrders;
global using EFSoft.Orders.Application.Queries.GetOrder;
global using EFSoft.Orders.Domain.RepositoryContracts;
global using EFSoft.Orders.Infrastructure.DBContexts;
global using EFSoft.Orders.Infrastructure.Repositories;
global using EFSoft.Shared.Cqrs.Configuration;
global using EFSoft.Shared.ServiceBus.DependencyInjection;

global using MediatR;

global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

﻿global using System.Diagnostics.CodeAnalysis;
global using Carter;
global using EFSoft.Orders.Api.Configuration;
global using EFSoft.Orders.Api.CreateOrder;
global using EFSoft.Orders.Api.GetCustomerOrders;
global using EFSoft.Orders.Api.GetOrder;
global using EFSoft.Orders.Api.UpdateOrder;
global using EFSoft.Orders.Api.UpdateOrderStatus;
global using EFSoft.Orders.Application.CreateOrder;
global using EFSoft.Orders.Application.GetOrder;
global using EFSoft.Orders.Application.UpdateOrder;
global using EFSoft.Orders.Application.UpdateOrderStatus;
global using EFSoft.Orders.Domain.Enums;
global using EFSoft.Orders.Domain.RepositoryContracts;
global using EFSoft.Orders.Infrastructure.DBContexts;
global using EFSoft.Orders.Infrastructure.Repositories;
global using EFSoft.Shared.Cqrs.Configuration;
global using EFSoft.Shared.ServiceBus.DependencyInjection;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

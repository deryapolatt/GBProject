using GBProject.Application.Features.CQRS.Handlers.AddressHandlers;
using GBProject.Application.Features.CQRS.Handlers.CustomerHandlers;
using GBProject.Application.Interfaces;
using GBProject.Application.Interfaces.AddressInterfaces;
using GBProject.Application.Interfaces.CustomerInterfaces;
using GBProject.Persistance.Context;
using GBProject.Persistance.Repositories;
using GBProject.Persistance.Repositories.AddressRepositories;
using GBProject.Persistance.Repositories.CustomerRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GBProjectContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
builder.Services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));

builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();
builder.Services.AddScoped<GetAddressWithCustomerQueryHandler>();


builder.Services.AddScoped<GetCustomerQueryHandler>();
builder.Services.AddScoped<GetCustomerByIdQueryHandler>();
builder.Services.AddScoped<CreateCustomerCommandHandler>();
builder.Services.AddScoped<UpdateCustomerCommandHandler>();
builder.Services.AddScoped<RemoveCustomerCommandHandler>();
builder.Services.AddScoped<GetCustomerWithAddressQueryHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

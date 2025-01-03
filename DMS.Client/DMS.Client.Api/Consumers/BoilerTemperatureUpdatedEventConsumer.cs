﻿using DMS.Client.Api.Caching;
using DMS.Monitor.Contracts.Public.Events.BoilerDevice;
using MassTransit;

namespace DMS.Client.Api.Consumers;

public class BoilerTemperatureUpdatedEventConsumer(
    BoilerTemperatureCache boilerTemperatureCache,
    ILogger<BoilerTemperatureUpdatedEventConsumer> logger) : IConsumer<BoilerTemperatureUpdatedEvent>
{
    public Task Consume(ConsumeContext<BoilerTemperatureUpdatedEvent> context)
    {
        logger.LogInformation("Saving updated temperature: {Temperature}°C", context.Message.TemperatureCelsius);

        boilerTemperatureCache.SetTemperature(context.Message.TemperatureCelsius);

        return Task.CompletedTask;
    }
}

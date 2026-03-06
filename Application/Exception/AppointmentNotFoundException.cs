using System;

namespace DesafioMagazineLuiza.Application.Exception;

public class AppointmentNotFoundException : global::System.Exception
{
    public AppointmentNotFoundException(Guid id)
        : base($"Appointment with id '{id}' was not found.")
    {
    }
}
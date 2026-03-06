using DesafioMagazineLuiza.Application.DTO;
using DesafioMagazineLuiza.Application.Exception;
using DesafioMagazineLuiza.Domain;
using DesafioMagazineLuiza.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DesafioMagazineLuiza.Application.Service;

public class AppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AppointmentResponse> CreateAppointment(
        AppointmentRequest request,
        CancellationToken cancellationToken = default)
    {
        var appointment = Appointment.Create(
            request.Date,
            request.Text,
            request.Recipient,
            request.ChannelType
        );

        _context.Appointments.Add(appointment);

        await _context.SaveChangesAsync(cancellationToken);

        return Map(appointment);
    }

    public async Task<AppointmentResponse> GetAppointmentById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var appointment = await _context.Appointments
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (appointment == null)
            throw new AppointmentNotFoundException(id);

        return Map(appointment);
    }

    public async Task DeleteAppointment(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (appointment == null)
            throw new AppointmentNotFoundException(id);

        _context.Appointments.Remove(appointment);

        await _context.SaveChangesAsync(cancellationToken);
    }

    private static AppointmentResponse Map(Appointment appointment)
    {
        return new AppointmentResponse
        {
            Id = appointment.Id,
            Date = appointment.Date,
            Text = appointment.Text,
            Recipient = appointment.Recipient,
            ChannelType = appointment.ChannelType,
            CreatedAt = appointment.CreatedAt,
            Status = appointment.Status
        };
    }
}
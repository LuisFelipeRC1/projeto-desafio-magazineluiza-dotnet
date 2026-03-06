using NodaTime;
using DesafioMagazineLuiza.Domain.Enum;

namespace DesafioMagazineLuiza.Domain;

public sealed class Appointment
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Text { get; private set; } = null!;
    public string Recipient { get; private set; } = null!;
    public ChannelType ChannelType { get; private set; }
    public LocalDateTime CreatedAt { get; private set; }
    public AppointmentStatus Status { get; private set; }

    private Appointment() { }

    public static Appointment Create(
        DateTime date,
        string text,
        string recipient,
        ChannelType channelType)
    {
        Validate(date, text, recipient);

        return new Appointment
        {
            Id = Guid.NewGuid(),
            Date = date,
            Text = text,
            Recipient = recipient,
            ChannelType = channelType,
            CreatedAt = LocalDateTime.FromDateTime(DateTime.UtcNow),
            Status = AppointmentStatus.Scheduled
        };
    }

    private static void Validate(DateTime date, string text, string recipient)
    {
        if (date < DateTime.UtcNow)
            throw new ArgumentException("Date must be in the future.");

        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text cannot be empty.");

        if (string.IsNullOrWhiteSpace(recipient))
            throw new ArgumentException("Recipient cannot be empty.");
    }
}
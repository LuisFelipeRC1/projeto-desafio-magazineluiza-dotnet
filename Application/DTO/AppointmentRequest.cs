using NodaTime;
using DesafioMagazineLuiza.Domain.Enum;

namespace DesafioMagazineLuiza.Application.DTO;

public  record AppointmentRequest {
    public DateTime Date { get; init; }
    public required string Text { get; init; }
    public required string Recipient { get; init; }
    public ChannelType ChannelType { get; init; }
    public AppointmentStatus Status { get; init; }
    public LocalDateTime CreatedAt { get; init; }


}
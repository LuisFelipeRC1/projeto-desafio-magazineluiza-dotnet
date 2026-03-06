using NodaTime;
using DesafioMagazineLuiza.Domain.Enum;

namespace DesafioMagazineLuiza.Application.DTO;

public  record AppointmentResponse {
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public required string Text { get; init; }
    public required string Recipient { get; init; }
    public ChannelType ChannelType { get; init; }
    public LocalDateTime CreatedAt { get; init; }
    public AppointmentStatus Status { get; init; }


}
namespace IISMSBackend.Dtos;

public record class CreateSalesRecordDto(
    string[] productName,
    decimal[] unitPrice,
    decimal [] totalUnitPrice,
    int [] quantity,
    int totalCartQuantity,
    decimal totalCartPrice
);
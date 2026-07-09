# ConferenceRoomBooking

Backend-сервис для управления бронью конференц-залов в организации. Реализован на .NET 8.

Реализованные функции (на текущем этапе)
- Создание брони: AddBookingCommand / AddBookingHandler
- Управление залами: AddConferenceRoomCommand, UpsertConferenceRoomCommand, DeleteConferenceRoomCommand
- Опциональные сервисы и расчет аренды: OptionalService, CalculateRentPriceQuery/Handler
- Репозитории: BookingRepository, ConferenceRoomRepository, OptionalServiceRepository (Infrastructure/ConferenceRoomBooking.Data)
- Правила ценообразования загружаются из JSON (Infrastructure/ConferenceRoomBooking.JSON/PricingRulesRepository)

Структура репозитория (фактическая)
- Core/ConferenceRoomBooking.Domain — доменные модели и сущности (BookingEntity, ConferenceRoomEntity, OptionalServiceEntity, PricingRuleEntity)
- Core/ConferenceRoomBooking.Application — команды/запросы, DTO, обработчики (AddBookingHandler, CalculateRentPriceHandler и др.)
- Infrastructure/ConferenceRoomBooking.Data — реализация персистенции (EF Core DbContext, репозитории, миграции). В папке присутствует sqlite БД для разработки: ConferenceRoomBookingDatabase.db
- Infrastructure/ConferenceRoomBooking.JSON — статические правила ценообразования (pricingRules.json) и репозиторий для них
- Pressentation/ConferenceRoomBooking.Api — HTTP API, контроллеры и точка входа

Архитектурные решения
- Подход слоёв (Onion/Clean): Domain не зависит от инфраструктуры; Application orchestrates use-cases; Infrastructure реализует репозитории и DbContext; Presentation — API.
- CQRS-паттерн: команды и запросы реализованы в Application (обработчики команд/запросов).
- Внедрение зависимостей через DI (Microsoft.Extensions.DependencyInjection) — репозитории и сервисы регистрируются в API проекте.
- Персистенция: EF Core (конфигурация через IEntityTypeConfiguration); для разработки используется sqlite, в продакшн можно переключить на SQL Server/Postgres через connection string.
- Конфигурация бизнес-правил ценообразования хранится в JSON (Infrastructure/ConferenceRoomBooking.JSON) и загружается через репозиторий правил.
- Транзакционность и обработка конфликтов: проверки конфликтов броней выполняются в Application-слое; при необходимости используются транзакции EF Core для атомарности.

Описание базы данных
- DbContext: ConferenceRoomBookingContext (Infrastructure/ConferenceRoomBooking.Data/Context).
- Основные таблицы (соответствуют сущностям в Domain): Bookings, ConferenceRooms, OptionalServices, BookingServices, RoomServices.
- Миграции расположены в Infrastructure/ConferenceRoomBooking.Data/Migrations.
- Для разработки в репозитории присутствует sqlite база: Infrastructure/ConferenceRoomBooking.Data/ConferenceRoomBookingDatabase.db.




# SpaceBot (C# / Windows)

Стартовый каркас нового проекта бота для 2D space-game в стиле DarkOrbit.

## Почему отдельный репозиторий
- Чистый старт без legacy Python-скриптов.
- Слои разделены: UI, Core, Vision, Input, Infrastructure.
- Легко масштабировать до ONNX/YOLO позже.

## Рекомендуемая среда
- Visual Studio 2019
- Windows Forms App (.NET Framework 4.7.2)

## MVP-цель
Стабильный сбор коробок с логикой:
1. Найти `bonus_box` и `event_box`.
2. Выбрать ближайшую к кораблю цель (только расстояние).
3. Зафиксировать цель (lock) и лететь к ней.
4. Не переключаться на другие цели в пути.
5. Дождаться подтверждения сбора и только потом выбрать новую.

## Структура
```text
SpaceBot/
  src/
    SpaceBot.App/
    SpaceBot.Core/
    SpaceBot.Vision/
    SpaceBot.Input/
    SpaceBot.Infrastructure/
  config/
    botsettings.json
```

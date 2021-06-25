# pochta-demo-app
Прототип приложения в рамках решения тестового задания для "Почта России"

Нужно написать два сервиса (можно консольных): сервис А и сервис Б. Сервисы для взаимодейстия используя брокер сообщений, при потере подключения, должны осуществлять попытки повторного подключения.
Сервис А - издатель:
Каждую секунду отправляет новое сообщение.Сообщения хранятся в локальной «базе». В случае перезапуска сервиса, выполняется восстановление своего последнего состояния. После восстановления осуществляется генерация и отправка новых сообщений.
Сообщение содержит:

порядковый номер
время отправки
произвольный текст
хэш предыдущего состояни всей "базы".

Сервис Б - подписчик:
Подписывается на канал событий и получает "новые" сообщения. После успешного полученя сохраняет их в «базу», каждому полученному сообщению присваивается временем получения.

Если есть желание сделать более продвинутое решение, необходимо дополнительно реализовать: В случае перезапуска сервиса, выполняется восстановление своего последнего состояния и происходит чтение с того момента, на котором был остановлен.

Ограничения:
1) Использовать C#
2) «База» удобный для тебя и надежный способ сохранения информации,
3) В качестве брокера сообщений можно использовать [nats streaming](https://nats.io/download/nats-io/nats-streaming-server/) или [nats](https://nats.io/download/nats-io/nats-server/)
4) Код должен показывать тебя с лучшей стороны. Команда, делая ревью должна увидеть в тебе «своего» человека с которым хочется работать

Данное решение демонстрирует общий концепт того, как я решал бы эту задачу. Возможны какие-то рассхождения с описанным выше заданием, т.к. непонятен был блок "Сервис А - издатель:
Каждую секунду отправляет новое сообщение.Сообщения хранятся в локальной «базе». В случае перезапуска сервиса, выполняется восстановление своего последнего состояния. После восстановления осуществляется генерация и отправка новых сообщений." Поэтому решение составлено просто с прицелом на то, чтобы дать общее представление о том, как бы я организовал кодовую базу для реализации этой задачи.

P.S. Ожидания от решения могут отличаться, т.к. первая часть задания крайне непонятна. "На нечеткое ТЗ, результат ХЗ =)"

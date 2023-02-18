fetch('/getMouses')
    .then((response) => response.json())
    .then((data) => console.log(data))
  // Получим ответ [{...}, {...}, {...}, ...]

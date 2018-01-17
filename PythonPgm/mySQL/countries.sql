SELECT COUNT(cities.name) AS city_count, countries.name FROM cities
JOIN countries WHERE countries.id = cities.country_id
GROUP BY countries.name;
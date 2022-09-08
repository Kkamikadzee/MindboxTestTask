SELECT p."name" product_name, c."name" category_name
	FROM product AS p 
	LEFT JOIN product_category AS pc ON pc.product_id = p.id
	LEFT JOIN category AS c ON c.id = pc.category_id
import { Product } from "../../app/models/products";
import ProductList from "./ProductList";
import { useEffect, useState } from "react";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch("http://localhost:5089/api/products").then((response) =>
      response.json().then((data) => setProducts(data))
    );
  }, []);

  return (
    <>
      <ProductList products={products} />
    </>
  );
}

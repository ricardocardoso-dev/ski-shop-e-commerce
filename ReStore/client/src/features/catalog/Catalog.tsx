import agent from "../../app/api/agent";
import { Product } from "../../app/models/products";
import ProductList from "./ProductList";
import { useEffect, useState } from "react";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
      agent.Catalog.list().then(products => setProducts(products))
  }, []);

  return (
    <>
      <ProductList products={products} />
    </>
  );
}

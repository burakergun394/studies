import React, { useEffect, useState } from "react";
import "./App.css";

import Container from "@mui/material/Container";
import Button from "@mui/material/Button";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";

interface ProductDto {
  id: number;
  code: string;
  name: string;
}

const dummyProducts: ProductDto[] = [
  { id: 1, code: "P-1", name: "Product-1" },
  { id: 2, code: "P-2", name: "Product-2" },
];

function App() {
  const [products, setProducts] = useState<ProductDto[]>(dummyProducts);

  return (
    <Container>
      <Button>Test</Button>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell align="left">Id</TableCell>
            <TableCell align="right">Code</TableCell>
            <TableCell align="right">Name</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {products.map((product) => {
            const { id, code, name } = product;
            return (
              <TableRow key={id}>
                <TableCell align="left">{id}</TableCell>
                <TableCell align="right">{code}</TableCell>
                <TableCell align="right">{name}</TableCell>
              </TableRow>
            );
          })}
        </TableBody>
      </Table>
    </Container>
  );
}

export default App;

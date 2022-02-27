import { Container } from "reactstrap";
import Navi from "../navi/Navi";
import Dashboard from "./Dashboard";
import { Routes, Route } from "react-router-dom";
import CartDetail from "../cart/CartDetail";
import NotFound from "../common/NotFound";
import AddOrUpdateProduct from "../products/AddOrUpdateProduct";

function App() {
  return (
    <Container>
      <Navi></Navi>
      <Routes>
        <Route exact path="/" element={<Dashboard />} />
        <Route exact path="/product" element={<Dashboard />} />
        <Route exact path="/cart" element={<CartDetail />} />
        <Route
          exact
          path="/saveproduct/:productId"
          element={<AddOrUpdateProduct />}
        />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Container>
  );
}

export default App;

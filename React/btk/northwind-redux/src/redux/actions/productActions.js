import * as actionTypes from "./actionTypes";

export const getProductsSuccess = (products) => {
  return { type: actionTypes.GET_PRODUCT_SUCCESS, payload: products };
};

export const getProducts = (categoryId) => {
  return function (dispatch) {
    let url = "http://localhost:3000/products";
    if (categoryId) {
      url = url + "?categoryId=" + categoryId;
    }
    return fetch(url)
      .then((response) => response.json())
      .then((response) => dispatch(getProductsSuccess(response)));
  };
};

export const createProductSuccess = (product) => {
  return { type: actionTypes.CREATE_PRODUCT_SUCCESS, payload: product };
};

export const updateProductSuccess = (product) => {
  return { type: actionTypes.UPDATE_PRODUCT_SUCCESS, payload: product };
};

export const saveProductApi = (product) => {
  return fetch("http://localhost:3000/products/" + (product.id || ""), {
    method: product.id ? "PUT" : "POST",
    headers: { "content-type": "application/json" },
    body: JSON.stringify(product),
  })
    .then(handleResponse)
    .catch(handleError);
};

export const saveProduct = (product) => {
  return function (dispatch) {
    return saveProductApi(product)
      .then((response) => {
        product.id
          ? dispatch(updateProductSuccess(response))
          : dispatch(createProductSuccess(response));
      })
      .catch((error) => {
        throw error;
      });
  };
};

export const handleResponse = async (response) => {
  if (response.ok) {
    return response.json();
  }

  const error = await response.text();
  throw new Error(error);
};

export const handleError = async (error) => {
  console.log("An error occured");
  throw new Error(error);
};

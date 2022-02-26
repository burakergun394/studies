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

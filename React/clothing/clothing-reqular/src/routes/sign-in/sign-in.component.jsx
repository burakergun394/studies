import { useEffect } from "react";
import {
  signInWithGooglePopup,
  signInWithGoogleRedirect,
  createUserDocumentFromAuth,
  getGoogleDirectResult,
} from "../../utils/firebase/firebase.utils";

const SignIn = () => {
  useEffect(async () => {
    const response = await getGoogleDirectResult();
    if (response) {
      const userDocRef = await createUserDocumentFromAuth(response.user);
    }
  }, []);
  const logGooglePopupUser = async () => {
    const { user } = await signInWithGooglePopup();
    const userDocRef = await createUserDocumentFromAuth(user);
  };

  return (
    <div>
      <h1>Sign In Page</h1>
      <button onClick={logGooglePopupUser}>Sign in with Google Popup</button>
      <button onClick={signInWithGoogleRedirect}>
        Sign in with Google Redirect
      </button>
    </div>
  );
};

export default SignIn;

import { Form, Formik } from 'formik';
import * as Yup from 'yup';

import { useLoginMutation } from '../../../app/apiServices/authService';
import { useAppDispatch } from '../../../app/hooks/stateHooks';
import { toastError } from '../../../app/react-toasts';
import { setCredentials } from '../../../app/state/slices/authSlice';
import FormikInputText from '../../common/UI/formik/FormikInputText';
import Button from '../../common/UI/inputs/Button';

interface FormValues {
  username: string;
  password: string;
}

const validationSchema = Yup.object({
  username: Yup.string().required('обязательное поле'),
  password: Yup.string().required('обязательное поле'),
});

const initialValues: FormValues = {
  username: '',
  password: '',
};

const LoginForm = () => {
  const dispatch = useAppDispatch();
  const [login, { isLoading }] = useLoginMutation();

  const handleSubmit = async (values: FormValues) => {
    try {
      const response = await login(values).unwrap();
      dispatch(
        setCredentials({
          token: response.jwtToken,
          account: response.account,
        })
      );
    } catch (err) {
      console.log(`ERROR: ${err}`);
      toastError('Неправильный логин или пароль!');
    }
  };

  return (
    <div className="font-nanito">
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting, isValid, dirty }) => (
          <Form>
            <div className="flex flex-col">
              <div>
                <div className="mb-1">Имя пользователя:</div>
                <FormikInputText name="username" />
              </div>
              <div className="mt-6 mb-9">
                <div className="mb-1">Пароль:</div>
                <FormikInputText name="password" type="password" />
              </div>

              <Button
                type="submit"
                label={isLoading ? 'Загрузка...' : 'Войти'}
                disabled={isSubmitting || !isValid || !dirty}
              />
            </div>
          </Form>
        )}
      </Formik>
    </div>
  );
};

export default LoginForm;

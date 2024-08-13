import { AxiosError } from 'axios';

const axiosResponseMessage = (error: AxiosError) => {
  if (error.response) {
    return (error.response.data as { message: string }).message;
  } else if (error.request) {
    return 'Request failed';
  } else {
    return 'Error';
  }
};

export default axiosResponseMessage;

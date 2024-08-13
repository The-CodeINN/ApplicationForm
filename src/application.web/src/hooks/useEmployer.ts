import axiosResponseMessage from '@/lib/axiosResponseMessage';
import EmployerService, {
  CreateProgramApplicationFormRequestDto,
} from '@/services/employerService';
import { useMutation } from '@tanstack/react-query';
import { AxiosError } from 'axios';
import { toast } from 'sonner';

const useEmployer = () => {
  const createFormMutation = useMutation({
    mutationFn: async (formData: CreateProgramApplicationFormRequestDto) => {
      const response = await EmployerService.createForm(formData);
      return response?.data;
    },
    onError: (error: AxiosError) => {
      toast.error(error.message);
      console.log(axiosResponseMessage(error));
    },
    onSuccess: (data) => {
      const { message, status } = data;
      return {
        message,
        status,
      };
    },
  });

  return { createFormMutation };
};

export default useEmployer;

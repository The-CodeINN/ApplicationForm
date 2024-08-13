import { Card, CardContent, CardHeader } from '../ui/card';

const InfoCard = ({
  title,
  children,
}: {
  title: string;
  children: React.ReactNode;
}) => {
  return (
    <Card className='text-xs lg:text-base'>
      <CardHeader className='bg-custom-mintgreen rounded-t-xl p-5 font-bold'>
        {title}
      </CardHeader>
      <CardContent className='p-6 pb-12'>{children}</CardContent>
    </Card>
  );
};

export default InfoCard;

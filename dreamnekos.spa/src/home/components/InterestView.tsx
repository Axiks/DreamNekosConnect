import { Button, Table } from 'flowbite-react';
import EditInterestModal from './EditInterestModal';
import { useContext } from 'react';
import { InterestControllContext } from '../context/InterestControllContext';

export default function InterestView(){
    const InterestControll = useContext(InterestControllContext);

    const onDelete = (interetstId: string) => {
        InterestControll.deleteInterest(interetstId);
    };

    return(
        <>
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                Interest name
                </Table.HeadCell>
                <Table.HeadCell>
                Inetest type
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Edit
                </span>
                </Table.HeadCell>
                <Table.HeadCell>    
                <span className="sr-only">
                    Delete
                </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
            {   InterestControll.interests.map((interest, index) => <Table.Row key={index} className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interest.name}
                    </Table.Cell>
                    <Table.Cell>
                        {interest.interestType?.name}
                    </Table.Cell>
                    <Table.Cell>
                        <EditInterestModal interestId={interest.interestId!}  />
                    </Table.Cell>
                    <Table.Cell>
                    <Button onClick={() => onDelete(interest.interestId!)}>
                        Delete
                    </Button>
                    </Table.Cell>
                </Table.Row> )}
            </Table.Body>
        </Table>
        </>
    )
}
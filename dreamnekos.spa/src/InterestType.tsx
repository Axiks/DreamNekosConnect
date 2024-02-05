import { Button, Table } from 'flowbite-react';
import { InterestResponse } from './services/openapi';
import EditModal from './EditModal';
import EditInterestModal from './EditModal';
import { useContext } from 'react';
import { InterestControllContexttt } from './context/InterestControllContext';

export default function InterestView(){
    const ttt = useContext(InterestControllContexttt);

    const onDelete = (interetstId: string) => {
        ttt.deleteInterest(interetstId);
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
            {   ttt.interests.map((interest, index) => <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interest.name}
                    </Table.Cell>
                    <Table.Cell>
                        {interest.interestType?.name}
                    </Table.Cell>
                    <Table.Cell>
                        {/* <a
                        href="/tables"
                        className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                        >
                        Edit
                        </a> */}
                        <EditInterestModal interest={interest}  />
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
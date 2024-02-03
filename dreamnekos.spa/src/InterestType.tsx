import { Table } from 'flowbite-react';
import { InterestResponse } from './services/openapi';

interface InterestViewProps {
    interests: InterestResponse[];
}

export default function InterestView(props: InterestViewProps){
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
                <span className="sr-only">
                    Delete
                </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
            {   props.interests.map((interest, index) => <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interest.name}
                    </Table.Cell>
                    <Table.Cell>
                        {interest.interestType?.name}
                    </Table.Cell>
                    <Table.Cell>
                        <a
                        href="/tables"
                        className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                        >
                        Edit
                        </a>
                    </Table.Cell>
                    <Table.Cell>
                        <a
                        href="/tables"
                        className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                        >
                        Delete
                        </a>
                    </Table.Cell>
                </Table.Row> )}
            </Table.Body>
            </Table>
        </>
    )
}
import React, { useEffect, useState } from 'react';
import { Table } from 'flowbite-react';
import { InterestTypeResponse } from './services/openapi';

interface InterestTypeViewProps {
    InterestTypes: InterestTypeResponse[];
}

function InterestTypeView(props: InterestTypeViewProps){
    return(
        <>
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                Interest type name
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
            {   props.InterestTypes.map((interestType, index) => 
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interestType.name}
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
                </Table.Row>
                )}
            </Table.Body>
            </Table>
        </>
    )
}

export default InterestTypeView
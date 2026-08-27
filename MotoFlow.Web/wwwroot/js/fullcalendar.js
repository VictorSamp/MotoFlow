window.motoFlowCalendar = {

    calendar: null,

    dotNetReference: null,

    initialize: function (elementId, dotNetReference) {

        const element =
            document.getElementById(elementId);

        if (!element) {
            console.error(
                `Elemento '${elementId}' não encontrado.`
            );

            return;
        }

        if (!window.FullCalendar) {
            console.error(
                "FullCalendar não foi carregado."
            );

            return;
        }

        this.dotNetReference =
            dotNetReference;

        if (this.calendar) {
            this.calendar.destroy();
        }

        this.calendar =
            new FullCalendar.Calendar(element, {

                initialView: 'dayGridMonth',

                locale: 'pt-br',

                firstDay: 1,

                height: 700,

                dayMaxEvents: true,

                navLinks: true,

                editable: false,

                selectable: false,

                headerToolbar: {
                    left: 'prev,next today',

                    center: 'title',

                    right:
                        'dayGridMonth,timeGridWeek,listWeek'
                },

                buttonText: {
                    today: 'Hoje',

                    month: 'Mês',

                    week: 'Semana',

                    list: 'Lista'
                },

                eventDisplay: 'block',

                eventTimeFormat: {
                    hour: '2-digit',

                    minute: '2-digit',

                    hour12: false
                },

                dateClick: function (info) {

                    window.motoFlowCalendar
                        .dotNetReference
                        .invokeMethodAsync(
                            'OnCalendarDateClicked',
                            info.dateStr
                        );
                },

                eventClick: function (info) {

                    info.jsEvent.preventDefault();

                    window.motoFlowCalendar
                        .dotNetReference
                        .invokeMethodAsync(
                            'OnCalendarEventClicked',
                            info.event.id
                        );
                },

                eventDidMount: function (info) {

                    const description =
                        info.event.extendedProps.description;

                    if (description) {

                        info.el.setAttribute(
                            'title',
                            description
                        );
                    }
                }
            });

        this.calendar.render();
    },


    setActivities: function (activities) {

        if (!this.calendar) {

            console.error(
                "Calendário ainda não foi inicializado."
            );

            return;
        }

        this.calendar.removeAllEvents();

        if (!activities ||
            activities.length === 0) {

            return;
        }

        const events =
            activities.map(activity => ({

                id: activity.id,

                title: activity.title,

                start: activity.startDate,

                end: activity.endDate,

                extendedProps: {

                    description:
                        activity.description,

                    members:
                        activity.members
                }
            }));

        this.calendar.addEventSource(events);
    }
};